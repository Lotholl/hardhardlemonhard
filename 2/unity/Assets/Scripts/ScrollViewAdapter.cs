using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewAdapter : MonoBehaviour
{

    public RectTransform prefarb;
    public Text countText;
    public RectTransform content;

    public void UpdateItems()
    {
        int modelsCount = 0;//кол-во элементов в списке
        int.TryParse(countText.text, out modelsCount);//получаем кол-во элементов
        StartCoroutine(GetItems(modelsCount, results => OnReceivedModels(results)));// запускаем функцию
    }

    void OnReceivedModels(TestItemModel[] models)//обработчик(рисуем элемент списка для каждого элемента модели)
    {
        foreach (Transform child in content)//убираем старый список
        {
            Destroy(child.gameObject);
        }

        foreach (var model in models)//создание объектов на сцене
        {
            var instance = GameObject.Instantiate(prefarb.gameObject) as GameObject;
            instance.transform.SetParent(content, false);
            InitializeItemView(instance, model);
        }
    }

    void InitializeItemView(GameObject viewGameObject, TestItemModel model)// передаем значения типа Item № и Button № на сцене
    {
        TestItemView view = new TestItemView(viewGameObject.transform);//данные с сервера применяем к обна сцене
        view.titleText.text = model.title;
        view.clickButton.GetComponentInChildren<Text>().text = model.buttonText;
        view.clickButton.onClick.AddListener(
            () =>
            {
                Debug.Log(view.titleText.text + " is clicked!");
            }
        );
    }

    IEnumerator GetItems(int count, System.Action<TestItemModel[]> callback)// эмулируем работу сервера
    {
        yield return new WaitForSeconds(1f);
        var results = new TestItemModel[count];
        for (int i = 0; i < count; i++)// cоздаем поля
        {
            results[i] = new TestItemModel();
            results[i].title = "Item " + i;
            results[i].buttonText = "Button " + i;
        }

        callback(results);
    }

    public class TestItemView
    {
        public Text titleText;
        public Button clickButton;

        public TestItemView(Transform rootView)
        {
            titleText = rootView.Find("TitleText").GetComponent<Text>();//ищем элемент на сцене
            clickButton = rootView.Find("ClickButton").GetComponent<Button>();
        }
    }

    public class TestItemModel //класс для описания модели данных
    {
        public string title;
        public string buttonText;
    }
}