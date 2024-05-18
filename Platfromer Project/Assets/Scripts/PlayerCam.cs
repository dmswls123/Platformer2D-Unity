using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ������ �������� ����

    Vector3 offset;                   // ī�޶�� �÷��̾��� ��ġ ����
    public Transform playerTransform; // �÷��̾��� ���� ��ġ (�÷��̾ ������ �� ����ǰ�, ī�޶� �ش� ��ġ�� ���̸�ŭ �Ѿư�)
    public float fixedYPosition;      // ī�޶��� Y��ġ�� ������Ű�� ���� ���� ��
    [Range(0f, 1f)]          // �Ʒ� ������ ũ�⸦ �����ϴ� ����Ƽ���� ����
    public float smoothValue;         // ī�޶��� ���� ����(�ε巯�� �������� ����) �� ��ġ ���̿� ��� ���� Percent �̵��� ����

    // Start is called before the first frame update
    void Start()
    {
        // transform = ī�޶�, ������ ��, ���� -> A - B: B���� ����ؼ� A���� �̵��ϴ� ȭ��ǥ
        offset = transform.position - playerTransform.position; //������ �Ÿ��� ����

        fixedYPosition = transform.position.y;
    }

    // Lerp. Linear Interpolation ���� ����
    // �� ������ �� ��, �� �� ������ ������ ��ġ�� ���� �ľ��ϱ� ���� ������ ����
    // �� ��(Point) - (Vector3). ī�޶��� ���� ��ġ. �̵� �ϰ� ���� ��ġ, ī�޶� -> ( Point) -> ��ǥ

    // �÷��̾��� ������ Update ����� �Ŀ� ī�޶� �ѾƼ� �����̱� ���ؼ�
    // Vector3.lerp�Լ� ������ �Ǿ�����
    void LateUpdate()
    {
        // �÷��̾ ������ ����

        Vector3 targetPosition = playerTransform.position + offset; //������ �� �������� ī�޶��� ��ġ�� ����
        targetPosition.y = fixedYPosition;   // ī�޶��� Y(����)�� ������Ŵ
        Vector3 smootPosition = Vector3.Lerp(transform.position, targetPosition, smoothValue);

        // ������ ��
        transform.position = targetPosition;  // ������ �÷��̾��� x�������θ� ����ٴϰ�, Y�� ������Ųä ī�޶� �̵�
    }
}
