import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-book',
  templateUrl: './show-book.component.html',
  styleUrls: ['./show-book.component.css']
})
export class ShowBookComponent implements OnInit {

  constructor(private service:SharedService) { }

  BookList:any=[];

  ngOnInit(): void {
    this.refreshBookList();
  }

  refreshBookList(){
    this.service.getBookList().subscribe(data => {
      this.BookList = data;
    });
  }

}
