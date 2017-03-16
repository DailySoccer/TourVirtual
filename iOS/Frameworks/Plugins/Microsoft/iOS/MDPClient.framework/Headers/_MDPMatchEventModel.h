//
//  _MDPMatchEventModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPMatchEventModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPMatchEventModelAttributes {
	__unsafe_unretained NSString *comment;
	__unsafe_unretained NSString *date;
	__unsafe_unretained NSString *eventType;
	__unsafe_unretained NSString *idAdvertisement;
	__unsafe_unretained NSString *idChallenge;
	__unsafe_unretained NSString *idEvent;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *minute;
	__unsafe_unretained NSString *second;
} MDPMatchEventModelAttributes;

extern const struct MDPMatchEventModelRelationships {
	__unsafe_unretained NSString *asset;
	__unsafe_unretained NSString *period;
	__unsafe_unretained NSString *textEventType;
	__unsafe_unretained NSString *timelineMatchEvents;
} MDPMatchEventModelRelationships;

extern const struct MDPMatchEventModelUserInfo {
	__unsafe_unretained NSString *mappedKeyName;
} MDPMatchEventModelUserInfo;

@class MDPAssetModel;
@class MDPKeyValueObjectModel;
@class MDPKeyValueObjectModel;
@class MDPTimelineModel;

@interface _MDPMatchEventModel : NSManagedObject

@property (nonatomic, strong) NSString* comment;

//- (BOOL)validateComment:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* date;

//- (BOOL)validateDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* eventType;

@property (atomic) uint16_t eventTypeValue;
- (uint16_t)eventTypeValue;
- (void)setEventTypeValue:(uint16_t)value_;

//- (BOOL)validateEventType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idAdvertisement;

//- (BOOL)validateIdAdvertisement:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idChallenge;

//- (BOOL)validateIdChallenge:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idEvent;

//- (BOOL)validateIdEvent:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* minute;

@property (atomic) uint64_t minuteValue;
- (uint64_t)minuteValue;
- (void)setMinuteValue:(uint64_t)value_;

//- (BOOL)validateMinute:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* second;

@property (atomic) uint64_t secondValue;
- (uint64_t)secondValue;
- (void)setSecondValue:(uint64_t)value_;

//- (BOOL)validateSecond:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPAssetModel *asset;

//- (BOOL)validateAsset:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPKeyValueObjectModel *period;

//- (BOOL)validatePeriod:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPKeyValueObjectModel *textEventType;

//- (BOOL)validateTextEventType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPTimelineModel *timelineMatchEvents;

//- (BOOL)validateTimelineMatchEvents:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPMatchEventModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveComment;
- (void)setPrimitiveComment:(NSString*)value;

- (NSDate*)primitiveDate;
- (void)setPrimitiveDate:(NSDate*)value;

- (NSNumber*)primitiveEventType;
- (void)setPrimitiveEventType:(NSNumber*)value;

- (uint16_t)primitiveEventTypeValue;
- (void)setPrimitiveEventTypeValue:(uint16_t)value_;

- (NSString*)primitiveIdAdvertisement;
- (void)setPrimitiveIdAdvertisement:(NSString*)value;

- (NSString*)primitiveIdChallenge;
- (void)setPrimitiveIdChallenge:(NSString*)value;

- (NSString*)primitiveIdEvent;
- (void)setPrimitiveIdEvent:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveMinute;
- (void)setPrimitiveMinute:(NSNumber*)value;

- (uint64_t)primitiveMinuteValue;
- (void)setPrimitiveMinuteValue:(uint64_t)value_;

- (NSNumber*)primitiveSecond;
- (void)setPrimitiveSecond:(NSNumber*)value;

- (uint64_t)primitiveSecondValue;
- (void)setPrimitiveSecondValue:(uint64_t)value_;

- (MDPAssetModel*)primitiveAsset;
- (void)setPrimitiveAsset:(MDPAssetModel*)value;

- (MDPKeyValueObjectModel*)primitivePeriod;
- (void)setPrimitivePeriod:(MDPKeyValueObjectModel*)value;

- (MDPKeyValueObjectModel*)primitiveTextEventType;
- (void)setPrimitiveTextEventType:(MDPKeyValueObjectModel*)value;

- (MDPTimelineModel*)primitiveTimelineMatchEvents;
- (void)setPrimitiveTimelineMatchEvents:(MDPTimelineModel*)value;

@end
