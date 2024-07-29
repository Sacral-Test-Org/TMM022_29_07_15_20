import { Component, OnInit } from '@angular/core';
import { FormInitializationService } from 'Frontend/TMM022_fmb/src/app/core/services/form-initialization.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {
  constructor(private formInitializationService: FormInitializationService) {}

  ngOnInit(): void {
    this.formInitializationService.initializeForm(this);
  }

  setTitle(): void {
    document.title = 'T K A P - [IS]';
  }

  displayCurrentDate(): void {
    const currentDate = new Date().toLocaleDateString();
    (document.getElementById('currentDateField') as HTMLInputElement).value = currentDate;
  }

  disableSaveButton(): void {
    (document.getElementById('saveButton') as HTMLButtonElement).disabled = true;
  }

  enableSpecificFields(): void {
    const fieldsToEnable = ['groupId', 'partNumber', 'partStatus', 'partDescription', 'lineId', 'unitId'];
    fieldsToEnable.forEach(fieldId => {
      const field = document.getElementById(fieldId) as HTMLInputElement;
      if (field) {
        field.disabled = false;
      }
    });
  }

  focusOnUnitID(): void {
    const unitIdField = document.getElementById('unitId') as HTMLInputElement;
    if (unitIdField) {
      unitIdField.focus();
    }
  }
}