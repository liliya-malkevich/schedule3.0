import { Component, OnInit, ChangeDetectionStrategy, Output, EventEmitter, ChangeDetectorRef, ViewChild } from '@angular/core';
import DataSource from 'devextreme/data/data_source';
import dxDataGrid from 'devextreme/ui/data_grid';
import { DxDataGridComponent,DxSelectBoxComponent } from 'devextreme-angular';
import { ScheduleService } from 'src/app/services/schedule.service';
import { ActivatedRoute,Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { SharedModule } from '../shared/shared.module';
import { BrowserModule } from '@angular/platform-browser';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: [],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ScheduleComponent implements OnInit{
  // @ViewChild('scheduleGrid') private _scheduleGrid!: DxDataGridComponent;
  @ViewChild("FacultySelectBox") private _FacultySelectBox!: DxSelectBoxComponent;
  @ViewChild("CourseSelectBox") private _CourseSelectBox!: DxSelectBoxComponent;
  @ViewChild("GroupSelectBox") private _GroupSelectBox!: DxSelectBoxComponent;
  @Output() onProcessProc = new EventEmitter();
  @Output() onRefreshMasterStore = new EventEmitter();

  public facultiesStore!: DataSource;
  public courseStore!: DataSource;
  public GroupStore!: DataSource;
  private _idF?: number;
  private _idKurs?: number;

  // Component visible
  public formVisible: boolean;
 public GroupNumbersVisible: boolean;
  // public numberDeptsVisible: boolean;
  public disableSave: boolean;
  constructor(private _cdr: ChangeDetectorRef, private _service: ScheduleService) {
    this.formVisible = true;
    this.disableSave = true;
    this.GroupNumbersVisible = false;
    this.facultiesStore = this._service.getFaculty();
    this.courseStore = this._service.getCourse();
  }

  ngOnInit(): void {

  }

  public openForm(idFaculty: number): void {
    this.formVisible = true;


    this._cdr.markForCheck();
  }

  public onFacultySelectionChanged(e: any): void {
    if (e.selectedRowsData.length > 0) {
      this._idF = e.selectedRowsData[0].IdF;
    } else {
      this.GroupNumbersVisible = false;

      this._idF = undefined;
    }
    this._cdr.markForCheck();
  }

  public onKursSelectionChanged(e: any): void {
    if (e.selectedRowsData.length > 0) {
      this.GroupNumbersVisible = true;

      this._idKurs = e.selectedRowsData[0].IdKurs;
      this.GroupStore = this._service.getGroup(1, this._idKurs,this._idF);

    } else {
      this.GroupNumbersVisible = false;

      this._idKurs = undefined;
    }
    this._cdr.markForCheck();
  }

  public onCloseForm(): void {
    this._GroupSelectBox.instance.reset();
    this._CourseSelectBox.instance.reset();
    this._FacultySelectBox.instance.reset();
  }

}
