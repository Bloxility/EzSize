# EzSize
An open source project to simplify the auto-sizing of C# Windows Form Apps.

## Usage
#### There is still issues with position and some with resizing (feel free to contribute)

### To resize whole form:

```cs
private void Form1_Load(object sender, EventArgs e)
{
  if(EzSize.intialiseResizer(this))
    {
      this.Resize += EzSize.resizeEvent;
    }
}
```
### To resize specific object:

```cs
private void Form1_Load(object sender, EventArgs e)
{
  if(EzSize.add(object))
    {
      this.Resize += EzSize.resizeEvent;
    }
}
```
#### The (small) Docs

```cs
bool add(Control i)               // Adds specific item to resize (can also use as add(Form i) )

bool intialiseResizer(Control i) //Adds whole form to resize
```
