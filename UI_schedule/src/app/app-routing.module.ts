import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ScheduleComponent } from './components/schedule/schedule.component';

const routes: Routes = [{path:'sch', component: ScheduleComponent, data:{title:'расписание'}}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
