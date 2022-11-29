import { Component,Input, OnChanges, OnDestroy, OnInit, Renderer2,ViewChild, enableProdMode, } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { locale, loadMessages } from "devextreme/localization";
import { filter, map, mergeMap } from 'rxjs/operators';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnDestroy{
  private _navbarDataSubscription!: Subscription;
  public headerTitle!: string;



  constructor(private router: Router,
    private activatedRoute: ActivatedRoute,

    private renderer: Renderer2) {

     locale(navigator.language);

     this._navbarDataSubscription = this.router.events.pipe(
       filter((event) => event instanceof NavigationEnd),
       map(() => this.activatedRoute),
       map((route: any) => {
         while (route.firstChild) route = route.firstChild;
         return route;
       }),
       filter((route) => route.outlet === 'primary'),
       mergeMap((route: any) => route.data)
     )
     .subscribe((event: any) => {
       if (event['title']) {
         this.headerTitle = event['title'];
        // this.configSideBar(this.headerTitle);
       } else {
         this.headerTitle = '';
       }


     });


    }

    public ngOnDestroy(): void {
      this._navbarDataSubscription.unsubscribe();
    }
}
