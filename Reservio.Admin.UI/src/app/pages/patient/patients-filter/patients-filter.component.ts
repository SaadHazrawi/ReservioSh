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
  isFirstNameFocused: boolean = false;
  isLastNameFocused: boolean = false;
  isRegionFocused: boolean = false;
  isGenderFocused: boolean = false;
  isDateOfBirthFocused: boolean = false;


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
      this.formatAndPatchDateOfBirth(this.searchForm, 'dateOfBirth');
      const filters: PatientFilter = this.searchForm.value;
      this.searchFilters.emit(filters);
    }
  }

  clearAllFilters() {
    this.searchForm.reset();
    this.searchForm.patchValue({'dateOfBirth':''});
    this.searchForm.patchValue({'gender':GenderPatient.Unknown});
    this.searchFilters.emit(this.searchForm.value);
  }


  onFocus(controlName: string): void {
    // Reset all focus states
    this.resetFocusStates();
    // Set focus state for the focused control
    switch (controlName) {
      case 'firstName':
        this.isFirstNameFocused = true;
        break;
      case 'lastName':
        this.isLastNameFocused = true;
        break;
      case 'region':
        this.isRegionFocused = true;
        break;
      case 'gender':
        this.isGenderFocused = true;
        break;
      case 'dateOfBirth':
        this.isDateOfBirthFocused = true;
        break;
      // Add cases for other controls if needed
    }
  }

  onBlur(): void {
    this.resetFocusStates();
  }

  private resetFocusStates(): void {
    this.isFirstNameFocused = this.isFormControlEmpty('firstName');
    this.isLastNameFocused = this.isFormControlEmpty('lastName');
    this.isRegionFocused = this.isFormControlEmpty('region');
    this.isGenderFocused = this.isFormControlEmpty('gender');
    this.isDateOfBirthFocused = this.isFormControlEmpty('dateOfBirth');
    
  }

  private isFormControlEmpty(controlName: string): boolean {
    const control = this.searchForm.get(controlName);
    return control.value !== '' ;
  }


  formatAndPatchDateOfBirth(form: FormGroup, columnName: string): void {
    const selectedDate = new Date(form.get(columnName).value);
    if (!isNaN(selectedDate.getTime())) {
      // Add one day to the selected date
      selectedDate.setDate(selectedDate.getDate() + 1);
      
      const formattedDate = selectedDate.toISOString();
      form.patchValue({ 'dateOfBirth': formattedDate });
    }
    
  }
}

