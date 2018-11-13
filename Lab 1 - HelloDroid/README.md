# Lab 1 - Hello World
Découverte de Xamarin.Droid

1. Ouvrir la solution (Start/HelloDroid.sln)
2. Ouvrir le layout content_mail.axml (Resources/layout/content_main.axml)
3. Dans l'onglet "code" ajouter dans le LinearLayout 3 composant
	- 2 champs de saisie (Username / Password)
	- 1 label (Fullname)
	Les champs doivent avoir des ID unique pour être accessible depuis le code C#
	
	<android.support.design.widget.TextInputLayout
		android:layout_width="match_parent"
		android:layout_height="wrap_content">
		<EditText
			android:id="@+id/firstname"
			android:layout_width="fill_parent"
			android:layout_height="wrap_content"
			android:hint="Prénom" />
	</android.support.design.widget.TextInputLayout>
	<android.support.design.widget.TextInputLayout
		android:layout_width="match_parent"
		android:layout_height="wrap_content">
		<EditText
			android:id="@+id/lastname"
			android:layout_width="fill_parent"
			android:layout_height="wrap_content"
			android:hint="Nom" />
	</android.support.design.widget.TextInputLayout>
	<TextView
		android:id="@+id/fullname"
		android:layout_width="match_parent"
		android:layout_height="wrap_content" />
		
4. Ouvrir la classe MainActivity.cs

5. A la fin de la méthode OnCreate, ajouter le code nécessaire pour récupérer les composant définis dans le AXML

	_firstnameTextView = FindViewById<EditText>(Resource.Id.firstname);
	_lastnameTextView = FindViewById<EditText>(Resource.Id.lastname);
	_fullnameTextView = FindViewById<TextView>(Resource.Id.fullname);

	_firstnameTextView.TextChanged += (sender, args) => RefreshFullname();
	_lastnameTextView.TextChanged += (sender, args) => RefreshFullname();
	
6. Les variables préfixée par "_" sont à definir comme champs privés au niveau de la classe

	private EditText _firstnameTextView;
	private EditText _lastnameTextView;
	private TextView _fullnameTextView;
	private string _fullname = string.Empty;
	
7. Ajouter la méthode RefresfFullname()

	private void RefreshFullname()
	{
		_fullname = string.Join(" ", _firstnameTextView.Text, _lastnameTextView.Text);
		_fullnameTextView.Text = _fullname;
	}
	
8. Lancer!