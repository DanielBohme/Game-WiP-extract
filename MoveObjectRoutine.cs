using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

public class MoveObjectRoutine : MonoBehaviour
{
    public IEnumerator MoveObjectPlusLeftHand(Transform objectToMove, Vector3 endPos, Transform leftHandObjectToMove, Vector3 endPosLeftHand, float time)
    {
        float currentTime = 0.0f;
        float normalizedDelta;
        Vector3 startPosition = objectToMove.localPosition;
        Vector3 endPosition = endPos;
        Vector3 startPositionLeftHand = leftHandObjectToMove.localPosition;
        Vector3 endPositionLeftHand = endPosLeftHand;
        while (currentTime < time)
        {
            currentTime += Time.deltaTime;
            normalizedDelta = currentTime / time;
            leftHandObjectToMove.localPosition = Vector3.Lerp(startPositionLeftHand, endPositionLeftHand, normalizedDelta);
            objectToMove.localPosition = Vector3.Lerp(startPosition, endPosition, normalizedDelta);
            yield return null;
        }
    }

    public IEnumerator MoveObject(Transform objectToMove, Vector3 endPos, float time)
    {
        float currentTime = 0.0f;
        float normalizedDelta;
        Vector3 startPosition = objectToMove.localPosition;
        Vector3 endPosition = endPos;
        while (currentTime < time)
        {
            currentTime += Time.deltaTime;
            normalizedDelta = currentTime / time;
            objectToMove.localPosition = Vector3.Lerp(startPosition, endPosition, normalizedDelta);
            yield return null;
        }
    }

    public IEnumerator RotateAndMoveObject(Transform objectToMove, Quaternion endRot, Vector3 endPos, float time)
    {
        float currentTime = 0.0f;
        float normalizedDelta;
        Quaternion startRotation = objectToMove.localRotation;
        Quaternion endRotation = endRot;
        Vector3 startPosition = objectToMove.localPosition;
        Vector3 endPosition = endPos;
        while (currentTime < time)
        {
            currentTime += Time.deltaTime;
            normalizedDelta = currentTime / time;
            objectToMove.localRotation = Quaternion.Lerp(startRotation, endRotation, normalizedDelta);
            objectToMove.localPosition = Vector3.Lerp(startPosition, endPosition, normalizedDelta);
            yield return null;
        }
    }

    protected IEnumerator PunchHandRoutine(Action<bool> punchingHand, Transform handTransform, Vector3 endPos, Vector3 returnPos, SphereCollider sCollider, float punchArmExtendedTime, float punchingRate)
    {
        bool boolToAssign = true;
        punchingHand(boolToAssign);
        handTransform.gameObject.SetActive(true);

        float currentTime = 0.0f;
        float normalizedDelta;
        Vector3 startPosHand = handTransform.localPosition;
        Vector3 endPosLeftHand = endPos;
        sCollider.enabled = true;
        while (currentTime < 0.12f)
        {
            currentTime += Time.deltaTime;
            normalizedDelta = currentTime / 0.2f;
            handTransform.localPosition = Vector3.Lerp(startPosHand, endPosLeftHand, normalizedDelta);
            yield return null;
        }

        yield return new WaitForSeconds(punchArmExtendedTime);

        sCollider.enabled = false;
        Vector3 returnPosHand = returnPos;
        currentTime = 0.0f;
        while (currentTime < 0.35f)
        {
            currentTime += Time.deltaTime;
            normalizedDelta = currentTime / 0.35f;
            handTransform.localPosition = Vector3.Lerp(endPosLeftHand, returnPosHand, normalizedDelta);
            yield return null;
        }
        yield return new WaitForSeconds(0.01f);
        handTransform.gameObject.SetActive(false);
        yield return new WaitForSeconds(punchingRate);
        boolToAssign = false;
        punchingHand(boolToAssign);
    }
}
