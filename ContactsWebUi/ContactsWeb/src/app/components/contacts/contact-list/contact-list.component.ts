import { Component, OnInit } from '@angular/core';
import { Contact } from 'src/app/models/contacts.model';
import { ContactsService } from 'src/app/services/contacts.service';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent implements OnInit {
  contacts: Contact[] = [];
  constructor(private contactsservice: ContactsService) { }

  ngOnInit(): void {
    this.contactsservice.getAllContacts().subscribe({
      next:(contacts)=>{
        
        console.log(contacts);
       this.contacts = contacts;
      },
      error:(response)=>{
        console.log(response);
      }
      })
  }

}
