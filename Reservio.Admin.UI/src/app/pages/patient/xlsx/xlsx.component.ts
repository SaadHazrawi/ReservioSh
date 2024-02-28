import { Component, Input } from '@angular/core';
import * as XLSX from 'xlsx';
@Component({
  selector: 'ngx-xlsx',
  templateUrl: './xlsx.component.html',
  styleUrls: ['./xlsx.component.scss']
})
export class XlsxComponent {
  @Input() elemntId: string;
 /**Default name for excel file when download**/
 fileName = 'ExcelSheet.xlsx';
 exportexcel() {
   /**passing table id**/
   let data = document.getElementById(this.elemntId);
   const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(data);
   /**Generate workbook and add the worksheet**/
   const wb: XLSX.WorkBook = XLSX.utils.book_new();
   XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
   /*save to file*/
   XLSX.writeFile(wb, this.fileName);
 }
}
