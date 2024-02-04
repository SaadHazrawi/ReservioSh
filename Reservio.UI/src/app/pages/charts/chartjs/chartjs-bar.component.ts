import { Component, OnDestroy } from "@angular/core";
import { NbThemeService, NbColorHelper } from "@nebular/theme";

@Component({
  selector: "ngx-chartjs-bar",
  template: ` <chart type="bar" [data]="data" [options]="options"></chart> `,
})
export class ChartjsBarComponent implements OnDestroy {
  data: any;
  options: any;
  themeSubscription: any;

  constructor(private theme: NbThemeService) {
    this.themeSubscription = this.theme.getJsTheme().subscribe((config) => {
      const colors: any = config.variables;
      const chartjs: any = config.variables.chartjs;

      this.data = {
        labels: ["01", "02", "03", "05"],
        datasets: [
          {
            data: [1, 0, 1, 0],
            label: "Heart Clinic",
            backgroundColor: "#F18F84",
          },
          {
            data: [0, 1, 0, 2],
            label: "Children's Clinic",
            backgroundColor: "#F9981B",
          },
          {
            data: [0, 1, 1, 1],
            label: "Eye Clinic",
            backgroundColor: "#5869F2",
          },
          {
            data: [1, 0, 0, 0],
            label: "Ear, Nose and Throat Clinic",
            backgroundColor: "#38CECD",
          },
          {
            data: [1, 0, 0, 0],
            label: "Dermatology Clinic",
            backgroundColor: "#ECF85D",
          },
        ],
      };
      // {
      //   labels: ['2', '3', '4', '6', '8', '9', '11'],
      //   datasets: [{
      //     data: [65, 59, 80, 81, 56, 55, 40],
      //     label: 'اطفال',
      //     backgroundColor: NbColorHelper.hexToRgbA(colors.primaryLight, 0.8),
      //   }, {
      //     data: [28, 48, 40, 19, 86, 27, 90],
      //     label: 'Series B',
      //     backgroundColor: NbColorHelper.hexToRgbA(colors.infoLight, 0.8),
      //   }],
      // };

      this.options = {
        maintainAspectRatio: false,
        responsive: true,
        legend: {
          labels: {
            fontColor: chartjs.textColor,
          },
        },
        scales: {
          xAxes: [
            {
              gridLines: {
                display: false,
                color: chartjs.axisLineColor,
              },
              ticks: {
                fontColor: chartjs.textColor,
              },
            },
          ],
          yAxes: [
            {
              gridLines: {
                display: true,
                color: chartjs.axisLineColor,
              },
              ticks: {
                fontColor: chartjs.textColor,
              },
            },
          ],
        },
      };
    });
  }

  ngOnDestroy(): void {
    this.themeSubscription.unsubscribe();
  }
}
