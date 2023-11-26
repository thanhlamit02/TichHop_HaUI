<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="DSLopHoc">
		<html>
			<title>DANH SÁCH LỚP HỌC</title>
			<table border="2" style="border-collapse: collapse" cellpadding="20px">
				<tr>
					<th>MaLop</th>
					<th>TenLop</th>
				</tr>
				<xsl:apply-templates select="LopHoc"/>
			</table>
		</html>
    </xsl:template>

	<xsl:template match="LopHoc">
		<tr>
			<td>
				<xsl:value-of select="MaLop"/>
			</td>
			<td>
				<xsl:value-of select="TenLop"/>
			</td>
		</tr>
	</xsl:template>
</xsl:stylesheet>
