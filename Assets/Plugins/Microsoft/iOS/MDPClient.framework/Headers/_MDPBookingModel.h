//
//  _MDPBookingModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPBookingModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPBookingModelAttributes {
	__unsafe_unretained NSString *card;
	__unsafe_unretained NSString *eventNumber;
	__unsafe_unretained NSString *idBooking;
	__unsafe_unretained NSString *idEvent;
	__unsafe_unretained NSString *idPlayer;
	__unsafe_unretained NSString *idTeam;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *minute;
	__unsafe_unretained NSString *playerName;
	__unsafe_unretained NSString *reason;
	__unsafe_unretained NSString *teamName;
} MDPBookingModelAttributes;

extern const struct MDPBookingModelRelationships {
	__unsafe_unretained NSString *footBallTeamDataBookings;
	__unsafe_unretained NSString *period;
} MDPBookingModelRelationships;

@class MDPFootballTeamDataModel;
@class MDPKeyValueObjectModel;

@interface _MDPBookingModel : NSManagedObject

@property (nonatomic, strong) NSString* card;

//- (BOOL)validateCard:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* eventNumber;

//- (BOOL)validateEventNumber:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idBooking;

//- (BOOL)validateIdBooking:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idEvent;

//- (BOOL)validateIdEvent:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idPlayer;

//- (BOOL)validateIdPlayer:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idTeam;

//- (BOOL)validateIdTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* minute;

@property (atomic) int64_t minuteValue;
- (int64_t)minuteValue;
- (void)setMinuteValue:(int64_t)value_;

//- (BOOL)validateMinute:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* playerName;

//- (BOOL)validatePlayerName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* reason;

//- (BOOL)validateReason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* teamName;

//- (BOOL)validateTeamName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFootballTeamDataModel *footBallTeamDataBookings;

//- (BOOL)validateFootBallTeamDataBookings:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPKeyValueObjectModel *period;

//- (BOOL)validatePeriod:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPBookingModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveCard;
- (void)setPrimitiveCard:(NSString*)value;

- (NSString*)primitiveEventNumber;
- (void)setPrimitiveEventNumber:(NSString*)value;

- (NSString*)primitiveIdBooking;
- (void)setPrimitiveIdBooking:(NSString*)value;

- (NSString*)primitiveIdEvent;
- (void)setPrimitiveIdEvent:(NSString*)value;

- (NSString*)primitiveIdPlayer;
- (void)setPrimitiveIdPlayer:(NSString*)value;

- (NSString*)primitiveIdTeam;
- (void)setPrimitiveIdTeam:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveMinute;
- (void)setPrimitiveMinute:(NSNumber*)value;

- (int64_t)primitiveMinuteValue;
- (void)setPrimitiveMinuteValue:(int64_t)value_;

- (NSString*)primitivePlayerName;
- (void)setPrimitivePlayerName:(NSString*)value;

- (NSString*)primitiveReason;
- (void)setPrimitiveReason:(NSString*)value;

- (NSString*)primitiveTeamName;
- (void)setPrimitiveTeamName:(NSString*)value;

- (MDPFootballTeamDataModel*)primitiveFootBallTeamDataBookings;
- (void)setPrimitiveFootBallTeamDataBookings:(MDPFootballTeamDataModel*)value;

- (MDPKeyValueObjectModel*)primitivePeriod;
- (void)setPrimitivePeriod:(MDPKeyValueObjectModel*)value;

@end
