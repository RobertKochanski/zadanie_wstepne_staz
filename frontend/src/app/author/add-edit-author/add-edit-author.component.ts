import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-author',
  templateUrl: './add-edit-author.component.html',
  styleUrls: ['./add-edit-author.component.css']
})

export class AddEditAuthorComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() author:any;
  id: number = 0;
  firstName:string = "";
  surName:string = "";

  ngOnInit(): void {
    this.id = this.author.id;
    this.firstName = this.author.firstName;
    this.surName = this.author.surName;
  }

  addAuthor(){
    var author = {
      firstName:this.firstName,
      surName:this.surName,
    }

    this.service.addAuthor(author).subscribe(res => {
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

  updateAuthor(){
    var author = {
      id:this.id,
      firstName:this.firstName,
      surName:this.surName,
    }
    var id:number = this.id;
    this.service.updateAuthor(id, author).subscribe(res => {
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
