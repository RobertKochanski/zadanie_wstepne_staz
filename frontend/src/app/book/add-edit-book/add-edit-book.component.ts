import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-book',
  templateUrl: './add-edit-book.component.html',
  styleUrls: ['./add-edit-book.component.css']
})
export class AddEditBookComponent implements OnInit {

  authorList$!:Observable<any[]>;

  constructor(private service:SharedService) { }

  @Input() book:any;
  id: number = 0;
  title:string = "";
  description:string = "";
  release_Date:string = "";
  authorId: number = 0;

  ngOnInit(): void {
    this.id = this.book.id;
    this.title = this.book.title;
    this.description = this.book.description;
    this.release_Date = this.book.release_Date;
    this.authorId = this.book.authorId;
    this.authorList$ = this.service.getAuthorList();
  }

  addBook(){
    var book = {
      title:this.title,
      description:this.description,
      release_Date:this.release_Date,
      authorId:this.authorId
    }

    this.service.addBook(book).subscribe(res => {
      var closeModalBtn = document.getElementById("add-edit-modal-close");
      if(closeModalBtn){
        closeModalBtn.click();
      }

      var showAddSuccess = document.getElementById("add-success-alert");
      if(showAddSuccess){
        showAddSuccess.style.display = "block";
      }
      setTimeout(function(){
        if(showAddSuccess){
          showAddSuccess.style.display = "none";
        }
      }, 4000);
    });
  }

  updateBook(){
    var book = {
      id:this.id,
      title:this.title,
      description:this.description,
      release_Date:this.release_Date,
      authorId:this.authorId
    }
    var id:number = this.id;
    this.service.updateBook(id, book).subscribe(res => {
      var closeModalBtn = document.getElementById("add-edit-modal-close");
      if(closeModalBtn){
        closeModalBtn.click();
      }

      var showUpdateSuccess = document.getElementById("update-success-alert");
      if(showUpdateSuccess){
        showUpdateSuccess.style.display = "block";
      }
      setTimeout(function(){
        if(showUpdateSuccess){
          showUpdateSuccess.style.display = "none";
        }
      }, 4000);
    });
  }

}
