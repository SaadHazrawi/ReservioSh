import { AfterViewInit, Component, OnDestroy } from '@angular/core';
import { NbThemeService } from '@nebular/theme';
import { BIService } from '../../service/bi.service';
import { SubSink } from 'subsink';

@Component({
  selector: 'ngx-echarts-pie',
  template: `
    <div echarts [options]="options" class="echart"></div>
  `,
})
export class EchartsPieComponent implements AfterViewInit, OnDestroy {
  options: any = {};
  themeSubscription: any;
  private subs = new SubSink();
  obj: any;

  constructor(private theme: NbThemeService,
    private biservice: BIService) {
  }



  ngAfterViewInit() {
    this.subs.sink = this.biservice.GetCountByGenderPatient().subscribe({
      next: (data) => {
        this.obj = data;
        this.themeSubscription = this.theme.getJsTheme().subscribe(config => {

          const colors = config.variables;
          const echarts: any = config.variables.echarts;

          this.options = {
            backgroundColor: echarts.bg,
            color: [colors.warningLight, colors.infoLight, colors.dangerLight, colors.successLight, colors.primaryLight],
            tooltip: {
              trigger: 'item',
              formatter: '{a} <br/>{b} : {c} ({d}%)',
            },
            legend: {
              orient: 'vertical',
              left: 'left',
              data: ['Male', 'Female'],
              textStyle: {
                color: echarts.textColor,
              },
            },
            series: [
              {
                name: 'Countries',
                type: 'pie',
                radius: '80%',
                center: ['50%', '50%'],
                data: this.obj,
                itemStyle: {
                  emphasis: {
                    shadowBlur: 10,
                    shadowOffsetX: 0,
                    shadowColor: echarts.itemHoverShadowColor,
                  },
                },
                label: {
                  normal: {
                    textStyle: {
                      color: echarts.textColor,
                    },
                  },
                },
                labelLine: {
                  normal: {
                    lineStyle: {
                      color: echarts.axisLineColor,
                    },
                  },
                },
              },
            ],
          };
        });
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  ngOnDestroy(): void {
    this.themeSubscription.unsubscribe();
    this.subs.unsubscribe();
  }
}
