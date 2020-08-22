<!DOCTYPE html>

<html lang="en">
<head runat="server">
	<title>VIAJES Y TURISMO</title>
	<script>
		function validar() {
			var dato = document.getElementById("dato");

			if (!dato.opMdelPlata.checked && !dato.opNiza.checked) {
                alert("Debe seleccionar un destino");
                return;
            }

			if (!dato.opTres.checked && !dato.opCuatro.checked) {
				alert("Debe seleccionar una categoría");
				return;
			}

            if (dato.txtCantidad.value == "") {
				alert("Debe ingresar la cantidad de personas");
				return;
			}

            if (dato.txtDias.value == "") {
				alert("Debe ingresar la cantidad de días");
				return;
			}

			dato.submit();
		}
	</script>
</head>

<body>
	<form id="dato" method="post" action="vuelta.aspx">
		<div>
			Formulario de cotización
		</div>
		<br />
		<div>
			<label>¿Dónde va de vacaciones?</label>
			<div>
				<input id="opMdelPlata" name="destino" type="radio" value="MdelPlata" />
				Mar del Plata
			</div>
			<div>
				<input id="opNiza" name="destino" type="radio" value="Niza" />
				Niza
			</div>
		</div>
		<br />
		<div>
			<label>¿Cuál es la categoría?</label>
			<div>
				<input id="opTres" name="estrella" type="radio" value="Tres" />
				Tres estrellas
			</div>
			<div>
				<input id="opCuatro" name="estrella" type="radio" value="Cuatro" />
				Cuatro estrellas
			</div>
		</div>
		<br />
		<div>
			<label>Cantidad de Personas</label>
			<div>
				<input type="text" id="txtCantidad" value="" name="personas" />
			</div>
		</div>
		<br />
		<div>
			<label>Cantidad de días</label>
			<div>
				<input type="text" id="txtDias" value="" name="dias" />
			</div>
		</div>
		<br />
		<div>
			<input type="button" value="Enviar" onclick="javascript:validar()" />
		</div>

	</form>
</body>
</html>
