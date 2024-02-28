import { Component, EventEmitter, Output } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { PatientFilter } from "../Model/patientFilter";
import { GenderPatient } from "../Model/genderPatient";

@Component({
  selector: 'ngx-patients-filter',
  templateUrl: './patients-filter.component.html',
  styleUrls: ['./patients-filter.component.scss']
})
export class PatientsFilterComponent {
  @Output() searchFilters = new EventEmitter<PatientFilter>(); 
  searchForm: FormGroup;
  
  constructor(private fb: FormBuilder) {
    this.searchForm = this.fb.group({
      firstName: ['', Validators.maxLength(100)], // Maximum length validator
      lastName: ['', Validators.maxLength(100)], // Maximum length validator
      region: ['', Validators.maxLength(100)], // Maximum length validator
      gender: [GenderPatient.Unknown],
      dateOfBirth: [''],
      pageNumber: [1], 
      pageSize: [50] 
    });
  }
  searchPatients() {
    if (this.searchForm.valid) {
      const filters: PatientFilter = this.searchForm.value;
      this.searchFilters.emit(filters);
    }
  }
}