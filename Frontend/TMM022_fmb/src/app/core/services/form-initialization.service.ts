import { Injectable } from '@angular/core';
import { FormComponent } from '../models/form-component.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FormInitializationService {
  constructor(private http: HttpClient) {}

  initializeForm(formComponent: FormComponent): void {
    this.maximizeWindow();
    this.setTitle('T K A P - [IS]');
    this.displayCurrentDate(formComponent);
    this.setGlobalParameter();
    const mode = this.determineMode();
    this.displayMode(formComponent, mode);
    this.setCursorStyle();
    this.disableSaveButton(formComponent);
    this.enableFields(formComponent);
    this.focusField(formComponent);
  }

  private maximizeWindow(): void {
    window.moveTo(0, 0);
    window.resizeTo(screen.width, screen.height);
  }

  private setTitle(title: string): void {
    document.title = title;
  }

  private displayCurrentDate(formComponent: FormComponent): void {
    const currentDate = new Date().toLocaleDateString();
    formComponent.currentDateField = currentDate;
  }

  private setGlobalParameter(): void {
    // Assuming global parameter is stored in localStorage for simplicity
    localStorage.setItem('GLOBAL_PARA', '0');
  }

  private determineMode(): string {
    const globalPara = localStorage.getItem('GLOBAL_PARA');
    return globalPara === '0' ? 'Create Mode' : 'Edit Mode';
  }

  private displayMode(formComponent: FormComponent, mode: string): void {
    formComponent.modeField = mode;
  }

  private setCursorStyle(): void {
    document.body.style.cursor = 'default';
  }

  private disableSaveButton(formComponent: FormComponent): void {
    formComponent.saveButtonDisabled = true;
  }

  private enableFields(formComponent: FormComponent): void {
    formComponent.groupIdEnabled = true;
    formComponent.partNumberEnabled = true;
    formComponent.partStatusEnabled = true;
    formComponent.partDescriptionEnabled = true;
    formComponent.lineIdEnabled = true;
    if (!formComponent.unitIdEnabled) {
      formComponent.unitIdEnabled = true;
    }
  }

  private focusField(formComponent: FormComponent): void {
    formComponent.focusField('unitId');
  }
}
