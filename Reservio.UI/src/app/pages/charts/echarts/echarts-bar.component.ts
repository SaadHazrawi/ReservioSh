

import { AfterViewInit, Component, OnDestroy } from '@angular/core';
import { NbThemeService } from '@nebular/theme';
import { BIService } from '../../service/bi.service';
import { SubSink } from 'subsink';

@Component({
  selector: 'ngx-echarts-bar',
  template: `
    <div echarts [options]="options" class="echart"></div>
  `,
})
export class EchartsBarComponent implements AfterViewInit, OnDestroy {
  options: any = {};
  themeSubscription: any;
  private subs = new SubSink();
  obj: any;

  constructor(private theme: NbThemeService,
    private biService: BIService) {
  }

  ngAfterViewInit() {
    this.subs.sink = this.biService.GetPatientInWeek().subscribe({
      next: (data) => {
        this.obj = data;
        this.themeSubscription = this.theme.getJsTheme().subscribe(config => {

          const colors: any = config.variables;
          const echarts: any = config.variables.echarts;

          this.options = {
            backgroundColor: echarts.bg,
            color: [colors.primaryLight],
            tooltip: {
              trigger: 'axis',
              axisPointer: {
                type: 'shadow',
              },
            },
            grid: {
              left: '3%',
              right: '4%',
              bottom: '3%',
              containLabel: true,
            },
            xAxis: [
              {
                type: 'category',
                data: [ 'Sun','Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
                axisTick: {
                  alignWithLabel: true,
                },
                axisLine: {
                  lineStyle: {
                    color: echarts.axisLineColor,
                  },
                },
                axisLabel: {
                  textStyle: {
                    color: echarts.textColor,
                  },
                },
              },
            ],
            yAxis: [
              {
                type: 'value',
                axisLine: {
                  lineStyle: {
                    color: echarts.axisLineColor,
                  },
                },
                splitLine: {
                  lineStyle: {
                    color: echarts.splitLineColor,
                  },
                },
                axisLabel: {
                  textStyle: {
                    color: echarts.textColor,
                  },
                },
              },
            ],
            series: [
              {
                name: 'Score',
                type: 'bar',
                barWidth: '60%',
                data:this.obj
              },
            ],
          };
        });
      }
    })
  }

  ngOnDestroy(): void {
    this.themeSubscription.unsubscribe();
    this.subs.unsubscribe();
  }
}