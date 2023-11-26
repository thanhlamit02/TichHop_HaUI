<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

	<xsl:template match="DS">
		<html>
			<body>
				<table border="1">
					<tr>
						<th>MaMh</th>
						<th>TenMh</th>
						<th>SoGio</th>
					</tr>
					<xsl:for-each select="MonHoc">
						<xsl:if test="SoGio>40">
							<tr>
								<td>
									<xsl:value-of select="MaMh"/>
								</td>
								<td>
									<xsl:value-of select="TenMh"/>
								</td>
								<td>
									<xsl:value-of select="SoGio"/>
								</td>
							</tr>
						</xsl:if>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
