import { Component, OnInit } from '@angular/core';
import { ApiListService } from '../api-list.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-topnav',
  templateUrl: './topnav.component.html',
  styleUrls: ['./topnav.component.scss']
})
export class TopnavComponent implements OnInit {

  constructor(private apiListService: ApiListService, private router: Router) { }

  ngOnInit(): void {
  }

  logout(){
    this.router.navigate(['/login']);
  }


}
