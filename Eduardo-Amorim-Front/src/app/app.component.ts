import { Component, OnInit } from '@angular/core';
import { AppService } from './app.service';
import { AbstractControl, FormBuilder, FormControl, FormGroup, NgForm, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { CalculoRequest } from './CalculoRequest';
import { CalculoResult } from './CalculoResult';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  constructor(private appService: AppService, private formBuilder: FormBuilder) {}

  title = 'Calulcar CDB';

  formularioSimulacao: FormGroup;
  request: CalculoRequest
  result: CalculoResult
  labelResult: boolean;

  ngOnInit(): void {

    this.formularioSimulacao = this.formBuilder.group({
      valor: [null, [Validators.required, this.maiorQueZeroValidador()]],
      mes: [null, [Validators.required, this.maiorQueUmValidador()]]
    });

    this.request = new CalculoRequest();
    this.result = new CalculoResult();
  }

  maiorQueZeroValidador(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const value = control.value;
      
      return value !== null && value > 0 ? null : { 'maiorQueZero': true };
    };
  }
  
  maiorQueUmValidador(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const value = control.value;
      
      return value !== null && value > 1 ? null : { 'maiorQueZero': true };
    };
  }
  
  calcularCDB() {

    this.validacaoObrigatoriedadeCampos();

    this.refresh(false);
    this.result = new CalculoResult();

    this.request.ValorMonetario = this.formularioSimulacao.controls['valor'].value;
    this.request.PrazoEmMeses = this.formularioSimulacao.controls['mes'].value;

    if(this.formularioSimulacao.valid){
      
      this.appService.simularCalculoCDB(this.request)
        .subscribe(sucess => {
          this.result.resultadoBruto = parseFloat(sucess.resultadoBruto.toFixed(2));
          this.result.resultadoLiquido = parseFloat(sucess.resultadoLiquido.toFixed(2));
          this.result.moedaReal = sucess.moedaReal;
          this.result.unidadeMonetaria = sucess.unidadeMonetaria;
		  
          this.refresh(true);
      },
      error => {
        alert('Ocorreu um erro, gentileza tentar outra vez')
        this.refresh(false);
      });  
    }
  }

  validacaoObrigatoriedadeCampos(): void {
    this.formularioSimulacao.controls['valor'].markAllAsTouched();
    this.formularioSimulacao.controls['mes'].markAllAsTouched();
  }

  refresh(showResult: boolean): void {
    this.labelResult = showResult;
  }
}
