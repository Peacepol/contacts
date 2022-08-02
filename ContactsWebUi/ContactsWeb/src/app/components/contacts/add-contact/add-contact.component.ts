import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Contact } from 'src/app/models/contacts.model';
import { ContactsService } from 'src/app/services/contacts.service';

@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrls: ['./add-contact.component.css']
})
export class AddContactComponent implements OnInit {
addContactRequest: Contact={
  id:'',
  firstName:'',
  lastName:'',
  companyName:'',
  mobileNumber:0,
  emailAddress:'',
};
  constructor(private contactService: ContactsService,private router: Router) { }

  ngOnInit(): void {
  }
  addContact(){
    this.contactService.addContact(this.addContactRequest).subscribe(
      {
        next:(contacts)=>{
         this.router.navigate(['/contacts']);
        }
      }
    );
  }
}
