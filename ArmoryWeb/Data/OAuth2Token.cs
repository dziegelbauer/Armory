﻿namespace ArmoryWeb.Data;

internal class OAuth2Token
{
    public string? access_token { get; set; }
    public string? token_type { get; set; }
    public uint expires_in { get; set; }
    public string? scope { get; set; }
}