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

  modalAdd(){
    this.author = {
      id: 0,
      firstName: null,
      surName: null,
    }

    this.ModalTitle = "Add Author";
    this.ActivateAddEditAuthorComp = true;
  }

  modalEdit(item:any){
    this.author = item;
    this.ModalTitle = "Edit Author";
    this.ActivateAddEditAuthorComp = true;
  }

  delete(item:any){
    if(confirm("Are you sure?")){
      this.service.deleteAuthor(item.id).subscribe(res => {
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
      this.refreshAuthorList();
      });
    }
  }

  modalClose(){
    this.ActivateAddEditAuthorComp = false;
    this.refreshAuthorList();
  }

  refreshAuthorList(){
    this.service.getAuthorList().subscribe(data=>{
      this.AuthorList=data;
    });
  }
}
