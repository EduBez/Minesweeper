//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "UnboundModeDemoCustomField.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma link "cxButtons"
#pragma link "cxLookAndFeelPainters"
#pragma link "cxGraphics"
#pragma link "cxLookAndFeels"
#pragma link "dxSkinsCore"
#pragma resource "*.dfm"
TUnboundModeDemoCustomFieldForm *UnboundModeDemoCustomFieldForm;
//---------------------------------------------------------------------------
__fastcall TUnboundModeDemoCustomFieldForm::TUnboundModeDemoCustomFieldForm(TComponent* Owner)
  : TForm(Owner)
{
}
//---------------------------------------------------------------------------

int __fastcall TUnboundModeDemoCustomFieldForm::ShowModal()
{
  SetFormPosition(this, 35, 45);
  return (TForm::ShowModal());
}
//---------------------------------------------------------------------------

void __fastcall TUnboundModeDemoCustomFieldForm::edtKeyPress(
      TObject *Sender, char &Key)
{
  if ((Key < '0') || ('9' < Key))
    Key = 7;
}
//---------------------------------------------------------------------------

