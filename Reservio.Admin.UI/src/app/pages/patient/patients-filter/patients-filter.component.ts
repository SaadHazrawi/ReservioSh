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
  selectGender = [];
  selectedOption;
  isFocused: boolean = false;
  
  constructor(private fb: FormBuilder) {
    this.searchForm = this.fb.group({
      firstName: ['', Validators.maxLength(100)],
      lastName: ['', Validators.maxLength(100)],
      region: ['', Validators.maxLength(100)],
      gender: [GenderPatient.Unknown],
      dateOfBirth: [''],
      pageNumber: [1],
      pageSize: [50]
    });

    this.selectGender = Object.keys(GenderPatient)
      .filter(key => isNaN(Number(key)))
      .map(key => ({
        value: GenderPatient[key],
        name: key
      }));
  }

  searchPatients() {
    if (this.searchForm.valid) {
      const filters: PatientFilter = this.searchForm.value;
      this.searchFilters.emit(filters);
    }
  }

  onfocus(): void {
    if (!this.searchForm.get('firstName').value) {
      this.isFocused = true;
      console.log(this.isFocused);
    }
  }

  onBlur(): void {
    if (!this.searchForm.get('firstName').value) {
      this.isFocused = false;
      console.log(this.isFocused);
    }
  }
}
