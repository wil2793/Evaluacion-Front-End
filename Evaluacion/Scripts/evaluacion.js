function habilitarCampos(cHabilitar) {
    var txtUser = document.getElementById('txtUser');
    var txtPass = document.getElementById('txtPass');
    var txtPNombre = document.getElementById('txtPNombre');
    var txtSNombre = document.getElementById('txtSNombre');
    var txtAPat = document.getElementById('txtAPat');
    var txtAMat = document.getElementById('txtAMat');

    var btnEditar = document.getElementById('btnEditar');
    var btnCancelar = document.getElementById('btnCancelar');
    var btnNuevo = document.getElementById('btnNuevo');
    var btnGuardar = document.getElementById('btnGuardar');

    switch (cHabilitar) {
        case 'Nuevo':
            txtUser.disabled = false;
            txtPass.disabled = false;
            txtPNombre.disabled = false;
            txtSNombre.disabled = false;
            txtAPat.disabled = false;
            txtAMat.disabled = false;
            txtUser.value = "";
            txtPass.value = "";
            txtPNombre.value = "";
            txtSNombre.value = "";
            txtAPat.value = "";
            txtAMat.value = "";

            btnEditar.classList.remove("d-inline-block");
            btnEditar.classList.add("d-none");
            btnNuevo.classList.add("d-none");
            btnNuevo.classList.remove("d-inline-block");
            btnCancelar.classList.remove("d-none");
            btnCancelar.classList.add("d-inline-block");
            btnGuardar.classList.add("d-inline-block");
            btnGuardar.classList.remove("d-none");

            document.getElementById('userId').value = 0;
            break;
        case 'Editar':
            txtUser.disabled = false;
            txtPass.disabled = false;
            txtPNombre.disabled = false;
            txtSNombre.disabled = false;
            txtAPat.disabled = false;
            txtAMat.disabled = false;

            btnEditar.classList.remove("d-inline-block");
            btnEditar.classList.add("d-none");
            btnNuevo.classList.add("d-none");
            btnNuevo.classList.remove("d-inline-block");
            btnCancelar.classList.remove("d-none");
            btnCancelar.classList.add("d-inline-block");
            btnGuardar.classList.add("d-inline-block");
            btnGuardar.classList.remove("d-none");
            break;
        case 'Cancelar':
            window.location.href = "/Home/Perfil";
    }
}

function habilitarCamposRecibo(cHabilitar) {
    var txtProveedor = document.getElementById('txtProveedor');
    var txtMonto = document.getElementById('txtMonto');
    var txtMoneda = document.getElementById('txtMoneda');
    var txtFecha = document.getElementById('txtFecha');
    var txtcomentario = document.getElementById('txtcomentario');

    var lNuevo = document.getElementById('lNuevo').value;

    var btnEditar = document.getElementById('btnEditar');
    var btnCancelar = document.getElementById('btnCancelar');
    var btnGuardar = document.getElementById('btnGuardar');

    switch (cHabilitar) {
        case 'Nuevo':
            txtProveedor.value = "";
            txtMonto.value = "";
            txtMoneda.value = txtMoneda
            txtFecha.value = "";
            txtcomentario.value = "";

            btnCancelar.classList.remove("d-none");
            btnCancelar.classList.add("d-inline-block");
            btnGuardar.classList.add("d-inline-block");
            btnGuardar.classList.remove("d-none");
            break;
        case 'Editar':
            btnCancelar.classList.remove("d-none");
            btnCancelar.classList.add("d-inline-block");
            btnGuardar.classList.add("d-inline-block");
            btnGuardar.classList.remove("d-none");
            break;
        case 'Cancelar':
            window.location.href = "/Home/Recibos";
    }
}