<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="DS">
		<html>
			<head>
				<style>
					div {
					border: 1px solid black;
					}

					h3 {
					padding-left: 28px;
					}

					table, tr, th, td {
					padding: 20px;
					}
					
					table { margin: 40px }
				</style>
			</head>
			<body>
				<h1 align="center">BẢNG LƯƠNG THÁNG</h1>
				<div>
					<xsl:for-each select="//congty">
					<h3>
						Tên công ty: <xsl:value-of select="@TenCT"/>
					</h3>
					<xsl:for-each select="donvi">
						<h3>
							Tên phòng: <xsl:value-of select="tendv"/>
						</h3>
						<table border="1" style="border-collapse: collapse">
							<tr>
								<th>STT</th>
								<th>Họ tên</th>
								<th>Ngày sinh</th>
								<th>Ngày công</th>
								<th>Lương</th>
							</tr>
							<xsl:for-each select="nhanvien">
								<tr>
									<td align="center">
										<xsl:value-of select="position()"/>
									</td>
									<td>
										<xsl:value-of select="hoten"/>
									</td>
									<td>
										<xsl:value-of select="ngaysinh"/>
									</td>
									<td>
										<xsl:value-of select="ngaycong"/>
									</td>
									<td>
										<xsl:if test="ngaycong &lt;= 20">
											<xsl:value-of select="ngaycong * 150000"/>
										</xsl:if>

										<xsl:if test="ngaycong &lt;= 25 and ngaycong &gt; 20">
											<xsl:value-of select="20 * 150000 + (ngaycong - 20) * 200000"/>
										</xsl:if>

										<xsl:if test="ngaycong &gt; 25">
											<xsl:value-of select="20 * 150000 + 5 * 200000 + (ngaycong - 25) * 250000"/>
										</xsl:if>
									</td>
								</tr>
							</xsl:for-each>
						</table>
					</xsl:for-each>
				</xsl:for-each>
				</div>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
