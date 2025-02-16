using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private readonly Customer _customer = new Customer("Silvio Sebastiany", "silvio.sebastiany@gmail.com");
        private readonly Product _product = new Product("Produto 1", 20, true);
        private readonly Discount _discount = new Discount(10, 0, DateTime.Now.AddDays(5));

        [TestMethod]
        [TestCategory("Domain")] //utilizado no visual studio para agrupar os testes]
        public void Dado_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_8_caracteres()
        {
            var order = new Order(_customer, 0, _discount);
            Assert.AreEqual(8, order.Number.Length);  // Assert: Verifica o resultado
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_seu_status_deve_ser_aguardando_pagamento()
        {
            var order = new Order(_customer, 0, _discount);
            Assert.AreEqual(EOrderStatus.WaitingPayment, order.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pagamento_do_pedido_seu_status_deve_ser_aguardando_entrega()
        {
            var order = new Order(_customer, 0, _discount);
            order.AddItem(_product, 1); // Total do pedido deve ser 10
            order.Pay(10);
            Assert.AreEqual(EOrderStatus.WaitingDelivery, order.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pedido_cancelado_seu_status_deve_ser_cancelado()
        {
            var order = new Order(_customer, 0, _discount);
            order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, order.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_item_sem_produto_o_mesmo_nao_deve_ser_adicionado()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_item_com_quantidade_zero_ou_menor_o_mesmo_nao_deve_ser_adicionado()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_valido_seu_total_deve_ser_50()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_expirado_o_valor_do_pedido_deve_ser_60()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_invalido_o_valor_do_pedido_deve_ser_60()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_de_10_o_valor_do_pedido_deve_ser_50()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_uma_taxa_de_entrega_de_10_o_valor_do_pedido_deve_ser_60()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pedido_sem_cliente_o_mesmo_deve_ser_invalido()
        {
            Assert.Fail();
        }
    }
}