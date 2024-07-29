import { Component, OnInit } from '@angular/core';
import { FormInitializationService } from './core/services/form-initialization.service';
import { FormComponent } from './features/form/form.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'TMM022_fmb';

  constructor(private formInitializationService: FormInitializationService) {}

  ngOnInit(): void {
    const formComponent = new FormComponent(this.formInitializationService);
    this.formInitializationService.initializeForm(formComponent);
  }
}