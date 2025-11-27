

let inputQuantidade = document.getElementById("inputQuantidade");
let inputValorUnitario = document.getElementById("inputValorUnitario");
let inputTotal = document.getElementById("inputTotal");
let inputQuantidadeFormulario = document.getElementById("inputQuantidadeFormulario");
let inputTotalFormulario = document.getElementById("inputTotalFormulario")
function calcularValorTotal(quantidade, valorUnitario) {
    return (quantidade * valorUnitario).toFixed(2).replace(".", ",")
}
function atualizarTotal() {
    let quantidade = parseFloat(inputQuantidade.value.replace(",", ".")) || 0;
    let valor = parseFloat(inputValorUnitario.value.replace(",", ".")) || 0;
    
    inputTotal.value = calcularValorTotal(quantidade, valor)
    inputQuantidadeFormulario.value = quantidade
    inputTotalFormulario.value = inputTotal.value
}

document.addEventListener("DOMContentLoaded", function () {
    inputQuantidade.addEventListener("input", atualizarTotal );
    inputValorUnitario.addEventListener("input", atualizarTotal );

    atualizarTotal();
})

