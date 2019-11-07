export enum ECodigoOperacao {
    Soma = 1,
    Subtracao,
    Multiplicacao,
    Divisao
}

export const DescricaoCodigoOperacao = new Map<number, string>([
    [ECodigoOperacao.Soma, 'Soma'],
    [ECodigoOperacao.Subtracao, 'Subtração'],
    [ECodigoOperacao.Multiplicacao, 'Multiplicação'],
    [ECodigoOperacao.Divisao, 'Divisão'],
]);
