import { Component } from '@angular/core';
import { Autor } from './autor.model';
import { isNgTemplate } from '@angular/compiler';
import { log } from 'util';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  fieldArray: Array<any> = [];
  newAttribute: any = {};

  firstField = true;
  quantidadeNomes :number = 0;
  firstFieldName = '';
  isEditItems: boolean = true;
  autores : Array<Autor> = []

  addFieldValue(index) {
      this.fieldArray.push(this.newAttribute);
      this.newAttribute = {};
  }

  deleteFieldValue(index) {
    this.fieldArray.splice(index, 1);
  }

  onEditCloseItems() {
    this.isEditItems = !this.isEditItems;

    this.autores = this.fieldArray.map(autor=> 
      {          
        return new Autor(null, autor.name)
      });

      this.autores.forEach(element => {
        console.log(element.nome);
      });
  }

  GerarCampos()
  {
    for (let index = 0; index < this.quantidadeNomes; index++) {
     console.log(index)
     this.addFieldValue(index);
    }
  }
}

