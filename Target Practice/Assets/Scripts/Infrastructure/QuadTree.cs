using System.Collections.Generic;
using UnityEngine;

public class QuadTree<T> where T : MonoBehaviour {
    public const int CELL_CAPACITY = 4;

    private Rect rect;
    private readonly List<T> items;
    private List<QuadTree<T>> children;
    private bool isDivided;

    public QuadTree(Rect rect) {
        this.rect = rect;
        items = new List<T>();
    }

    public void Add(T t) {
        if (items.Count < CELL_CAPACITY) {
            items.Add(t);
            return;
        }

        if (!isDivided) {
            Divide();
        }

        foreach (QuadTree<T> child in children) {
            if (child.rect.Contains(t.transform.position)) {
                child.Add(t);
                break;
            }
        }
    }

    public void Remove(T t) {
        if (items.Remove(t)) {
            return;
        }

        foreach (QuadTree<T> child in children) {
            if (child.rect.Contains(t.transform.position)) {
                child.Remove(t);
                break;
            }
        }
    }

    private void Divide() {
        children = new List<QuadTree<T>>();

        Rect topLeftRect = rect;
        topLeftRect.xMax = rect.center.x;
        topLeftRect.yMin = rect.center.y;
        children.Add(new QuadTree<T>(topLeftRect));

        Rect topRightRect = rect;
        topRightRect.xMin = rect.center.x;
        topRightRect.yMin = rect.center.y;
        children.Add(new QuadTree<T>(topRightRect));

        Rect bottomLeftRect = rect;
        bottomLeftRect.xMax = rect.center.x;
        bottomLeftRect.yMax = rect.center.y;
        children.Add(new QuadTree<T>(bottomLeftRect));

        Rect bottomRightRect = rect;
        bottomRightRect.xMin = rect.center.x;
        bottomRightRect.yMax = rect.center.y;
        children.Add(new QuadTree<T>(bottomRightRect));

        isDivided = true;
    }

    public T Query(Vector2 position, float radius) {
        Rect queryRect = new Rect(position, Vector2.one * radius);
        T closestT = null;
        float shortestDistance = float.MaxValue;

        foreach (T item in items) {
            float distance = Vector2.Distance(item.transform.position, position);

            if (distance < shortestDistance) {
                shortestDistance = distance;
                closestT = item;
            }
        }

        foreach (QuadTree<T> child in children) {
            if (!queryRect.Overlaps(child.rect)) continue;

            T t = child.Query(position, radius);

            float distance = Vector2.Distance(t.transform.position, position);

            if (distance < shortestDistance) {
                shortestDistance = distance;
                closestT = t;
            }
        }

        return closestT;
    }

    public void DrawDebugGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(rect.center, rect.size);

        foreach (QuadTree<T> child in children) {
            child.DrawDebugGizmos();
        }
    }
}