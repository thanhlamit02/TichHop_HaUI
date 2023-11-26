<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="Truong">
		<html>
			<head>
				<title>Thông tin các lớp học</title>
			</head>
			<body>
				<table border="1">
					<tr>
						<th>Mã lớp</th>
						<th>Tên lớp</th>
					</tr>
					<xsl:apply-templates select="Lop"/>
				</table>
			</body>
		</html>
    </xsl:template>
	<xsl:template match="Lop">
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
