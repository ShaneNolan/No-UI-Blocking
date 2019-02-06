# No-UI-Blocking
C# code that mimics ShowDialog() behavior and more without blocking the UI.

## The Problem
When you want a form to return an object you need to use ShowDialog(), unfortunately this function causes the UI to block preventing the user from switching to another form to view details, logs, etc.

## Solution
```C#
public static void ShowForm(dynamic frm, Action func)
{
    frm.FormClosed += new FormClosedEventHandler((s, ev) => { func(); });
    frm.Show();
}

private void Btn_Show_Click(object sender, EventArgs e)
{
    FrmDisplay frmDisplay = new FrmDisplay();
    ShowForm(frmDisplay, () => {
        // Do something.
    });
}
```

The **dynamic** keyword allows for the Form being passed in to be generic i.e. a login form and a dashboard form.

The **action** keyword allows for anonymous function to be passed in, which will be called on the form closing event.

## Additional 
You can replace/add on to the original form Show function by using the new keyword, e.g. prepopulating a UI with information.

```C#
public new void Show()
{
    SetupUI();
    base.Show();
}
```
