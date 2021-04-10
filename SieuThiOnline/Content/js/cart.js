var cart = {
    init: function () {
        this.addProductInCart();
    },
    addProductInCart: function () {
        $('.add-product').on('click', function () {
            var id = $(this).data('id');
            var qty = qtyInput.value ? qtyInput.value : null;
            $.ajax({
                url: "/Cart/insertCart",
                data: { id: id, qty: qty },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    $('.count').text(response.count);
                    $('.modal-message').text(response.status);
                    $('.modal-message').addClass('show-modal-message');
                }
            })
            setTimeout(function () {
                $('.modal-message').removeClass('show-modal-message');
            }, 2000)
        })
    },
   
}

cart.init();