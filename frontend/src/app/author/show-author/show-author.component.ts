import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-author',
  templateUrl: './show-author.component.html',
  styleUrls: ['./show-author.component.css']
})
export class ShowAuthorComponent implements OnInit {

  constructor(private service:SharedService) { }

  AuthorList:any=[];

  ModalTitle:string="";
  ActivateAddEditAuthorComp:boolean=false;
  author:any;

  ngOnInit(): void {
    this.refreshAuthorList();
  }

  refreshAuthorList(){
    this.service.getAuthorList().subscribe(data=>{
      this.AuthorList=data;
    });
  }
}
