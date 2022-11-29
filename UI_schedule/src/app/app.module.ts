import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ScheduleComponent } from './components/schedule/schedule.component';
import { DevextremeModule } from './components/shared/devextreme/devextreme.module';
import { SharedModule } from './components/shared/shared.module';

@NgModule({
  declarations: [
    AppComponent,
    ScheduleComponent
  ],
  imports: [
    BrowserModule,
    SharedModule,
    DevextremeModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
