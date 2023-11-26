<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="KetQua">
		<html>
			<body>
				<table border="1">
					<tr>
						<th>Mã sv</th>
						<th>Mã mh</th>
						<th>Điểm thi</th>
					</tr>
					<xsl:for-each select="SinhVien">
						<xsl:sort select="MonHoc/DiemThi" order="ascending"/>
						<xsl:for-each select="MonHoc">
							<xsl:if test="MaMh='THVP' and DiemThi>=5">
								<tr>
									<td>
										<xsl:value-of select="//SinhVien/@MaSv"/>
									</td>
									<td>
										<xsl:value-of select="MaMh"/>
									</td>
									<td>
										<xsl:value-of select="DiemThi"/>
									</td>
								</tr>
							</xsl:if>
						</xsl:for-each>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
