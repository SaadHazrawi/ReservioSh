import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ScheduleTableComponent } from "./schedule-table/schedule-table.component";
import { ScheduleComponent } from "./ScheduleComponent";
import { ScheduleViewComponent } from "./schedule-view/schedule-view.component";

const routes: Routes = [
  {
    path: "",
    component: ScheduleTableComponent,
    children: [
      {
        path: "schedule-table",
        component: ScheduleTableComponent,
      },
    ],
  },
  {
    path: "view",
    component: ScheduleViewComponent,
    children: [
      {
        path: "",
        component: ScheduleViewComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ScheduleRoutingModule {}
export const routedComponents = [ScheduleTableComponent, ScheduleComponent,ScheduleViewComponent];
