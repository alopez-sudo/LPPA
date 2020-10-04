<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:template match="/">
      <h4>Cuenta de titulares</h4>
      <table border="2" cellpadding="5">
        <thead>
          <th>Num. cuenta</th>
          <th>Titular</th>
          <th>Saldo</th>
          <th>Sucursal</th>
        </thead>
        <tbody>
          <xsl:for-each select="Banco/Cuenta[CuentaSucursal='Barcelona']">
            <tr align="center">
              <td>
                <xsl:value-of select="@cuentanum"/>
              </td>
              <td>
                <xsl:value-of select="CuentaNombre"/>
              </td>
              <td>
                <xsl:value-of select="CuentaSaldo"/>
              </td>
              <td>
                <xsl:value-of select="CuentaSucursal"/>
              </td>
            </tr>
          </xsl:for-each>
        </tbody>
      </table>
    </xsl:template>
</xsl:stylesheet>
