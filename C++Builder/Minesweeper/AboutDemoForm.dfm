object formAboutDemo: TformAboutDemo
  Left = 266
  Top = 113
  BorderStyle = bsSizeToolWin
  BorderWidth = 8
  Caption = 'About this demo'
  ClientHeight = 392
  ClientWidth = 252
  Color = clWindow
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  FormStyle = fsStayOnTop
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object redDescription: TcxRichEdit
    Left = 0
    Top = 0
    Align = alClient
    ParentColor = True
    Properties.PlainText = True
    Properties.ReadOnly = True
    Properties.ScrollBars = ssVertical
    Style.BorderStyle = ebsNone
    Style.HotTrack = False
    Style.TransparentBorder = False
    TabOrder = 0
    Height = 392
    Width = 252
  end
end
