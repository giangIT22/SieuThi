var cart = {
    init: function () {
        this.addProductInCart();
        this.checkLogin();
    },
    addProductInCart: function () {
        
        $('.add-product').on('click', function (e) {
            var id = $(this).data('id');
            var qty = qtyInput.value ? qtyInput.value : null;

            $.ajax({
                url: "/Cart/insertCart",
                data: { id: id, qty: qty },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    
                    $('.modal-message').text(response.status);
                    $('.modal-message').addClass('show-modal-message');
                }
            })

            setTimeout(function () {
                $('.modal-message').removeClass('show-modal-message');
            }, 1500)
            window.location = "/Product/Detail?id=" + id;
            
        })
    },

    checkLogin: function () {
        $('.checkout').click(function (e) {
            
            $.ajax({
                url: "/Cart/checkLogin",
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response.status)
                    if (response.status) {
                        window.location = "/Home/Index";
                    } else {
                        window.location.href = "/Login/Index";
                    }
                }
            })

        })
    },
   
}

cart.init();