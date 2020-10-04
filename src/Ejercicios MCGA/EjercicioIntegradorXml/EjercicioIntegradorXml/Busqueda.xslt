<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:param name="ParamEditorial"></xsl:param>
  
  <xsl:template match="/">
    <table border="2" cellpadding="5">
      <thead>
        <th>Nombre</th>
        <th>Autor</th>
        <th>Editorial</th>
        <th>Precio</th>
      </thead>
      <tbody>
        <xsl:for-each select="Libros/Libro[Editorial=$ParamEditorial]">
          <tr align="center">
            <td>
              <xsl:value-of select="NombreLibro"/>
            </td>
            <td>
              <xsl:value-of select="Autor"/>
            </td>
            <td>
              <xsl:value-of select="Editorial"/>
            </td>
            <td>
              <xsl:value-of select="Precio"/>
            </td>
          </tr>
        </xsl:for-each>
      </tbody>
    </table>
  </xsl:template>
</xsl:stylesheet>
