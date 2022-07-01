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

  ModalTitle:string="";
  ActivateAddEditBookComp:boolean=false;
  book:any;

  ngOnInit(): void {
    this.refreshBookList();
  }

  modalAdd(){
    this.book = {
      id: 0,
      title: null,
      description: null,
      release_Date: null,
      authorId: 0
    }

    this.ModalTitle = "Add Book";
    this.ActivateAddEditBookComp = true;
  }

  modalEdit(item:any){
    this.book = item;
    this.ModalTitle = "Edit Book";
    this.ActivateAddEditBookComp = true;
  }

  delete(item:any){
    if(confirm("Are you sure?")){
      this.service.deleteBook(item.id).subscribe(res => {
        var closeModalBtn = document.getElementById("add-edit-modal-close");
      if(closeModalBtn){
        closeModalBtn.click();
      }

      var showDeleteSuccess = document.getElementById("delete-success-alert");
      if(showDeleteSuccess){
        showDeleteSuccess.style.display = "block";
      }
      setTimeout(function(){
        if(showDeleteSuccess){
          showDeleteSuccess.style.display = "none";
        }
      }, 4000);
      this.refreshBookList();
      });
    }
  }

  modalClose(){
    this.ActivateAddEditBookComp = false;
    this.refreshBookList();
  }

  refreshBookList(){
    this.service.getBookList().subscribe(data => {
      this.BookList = data;
    });
  }

}
