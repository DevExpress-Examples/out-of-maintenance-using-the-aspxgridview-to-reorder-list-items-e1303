using System;

public class SampleDataItem {
    int m_pos;
    string m_title;
    int m_quantity;
    Guid m_pk;

    public SampleDataItem(string title, int quantity) {
        m_pk = Guid.NewGuid();
        m_title = title;
        m_quantity = quantity;
    }

    public Guid Pk { get { return m_pk; } }
    public string Title { get { return m_title; } }
    public int Quantity { get { return m_quantity; } }
}
