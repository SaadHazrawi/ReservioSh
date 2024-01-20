import { Component, OnDestroy } from "@angular/core";
import { NbThemeService } from "@nebular/theme";
import { BIService } from "../../service/bi.service";
import { SubSink } from "subsink";

@Component({
  selector: "ngx-chartjs-pie",
  template: ` <chart type="pie" [data]="data" [options]="options"></chart> `,
})
export class ChartjsPieComponent implements OnDestroy {
  data: any;
  options: any;
  themeSubscription: any;
  private subs = new SubSink();
  objData: any;
  objLabel: any;
  objColor:any;
  constructor(private theme: NbThemeService, private biService: BIService) {
    this.subs.sink = this.biService.GetPatientInClinic().subscribe({
      next: (data) => {
        this.objLabel = data.clinicNames;
        this.objData= data.countPatients;
        this.objColor=data.randomColor
        console.log(this.objData);
        console.log(this.objLabel);
        this.themeSubscription = this.theme.getJsTheme().subscribe((config) => {
          const colors: any = config.variables;
          const chartjs: any = config.variables.chartjs;

          this.data = {
            labels: this.objLabel,
            datasets: [
              {
                data: this.objData,
                backgroundColor:this.objColor,
              },
            ],
          };

          this.options = {
            maintainAspectRatio: false,
            responsive: true,
            scales: {
              xAxes: [
                {
                  display: false,
                },
              ],
              yAxes: [
                {
                  display: false,
                },
              ],
            },
            legend: {
              labels: {
                fontColor: chartjs.textColor,
              },
            },
          };
        });
      },
    });
  }
  ngOnDestroy(): void {
    this.themeSubscription.unsubscribe();
  }
}
