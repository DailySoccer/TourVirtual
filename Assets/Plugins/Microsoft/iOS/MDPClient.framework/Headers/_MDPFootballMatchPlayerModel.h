//
//  _MDPFootballMatchPlayerModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPFootballMatchPlayerModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPFootballMatchPlayerModelAttributes {
	__unsafe_unretained NSString *alias;
	__unsafe_unretained NSString *captain;
	__unsafe_unretained NSString *idPlayer;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *playerName;
	__unsafe_unretained NSString *shirtNumber;
	__unsafe_unretained NSString *status;
} MDPFootballMatchPlayerModelAttributes;

extern const struct MDPFootballMatchPlayerModelRelationships {
	__unsafe_unretained NSString *footballTeamDataPlayerLineUp;
	__unsafe_unretained NSString *position;
} MDPFootballMatchPlayerModelRelationships;

@class MDPFootballTeamDataModel;
@class MDPKeyValueObjectModel;

@interface _MDPFootballMatchPlayerModel : NSManagedObject

@property (nonatomic, strong) NSString* alias;

//- (BOOL)validateAlias:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* captain;

@property (atomic) BOOL captainValue;
- (BOOL)captainValue;
- (void)setCaptainValue:(BOOL)value_;

//- (BOOL)validateCaptain:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idPlayer;

//- (BOOL)validateIdPlayer:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* playerName;

//- (BOOL)validatePlayerName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* shirtNumber;

@property (atomic) int64_t shirtNumberValue;
- (int64_t)shirtNumberValue;
- (void)setShirtNumberValue:(int64_t)value_;

//- (BOOL)validateShirtNumber:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* status;

@property (atomic) uint16_t statusValue;
- (uint16_t)statusValue;
- (void)setStatusValue:(uint16_t)value_;

//- (BOOL)validateStatus:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFootballTeamDataModel *footballTeamDataPlayerLineUp;

//- (BOOL)validateFootballTeamDataPlayerLineUp:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPKeyValueObjectModel *position;

//- (BOOL)validatePosition:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPFootballMatchPlayerModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAlias;
- (void)setPrimitiveAlias:(NSString*)value;

- (NSNumber*)primitiveCaptain;
- (void)setPrimitiveCaptain:(NSNumber*)value;

- (BOOL)primitiveCaptainValue;
- (void)setPrimitiveCaptainValue:(BOOL)value_;

- (NSString*)primitiveIdPlayer;
- (void)setPrimitiveIdPlayer:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitivePlayerName;
- (void)setPrimitivePlayerName:(NSString*)value;

- (NSNumber*)primitiveShirtNumber;
- (void)setPrimitiveShirtNumber:(NSNumber*)value;

- (int64_t)primitiveShirtNumberValue;
- (void)setPrimitiveShirtNumberValue:(int64_t)value_;

- (NSNumber*)primitiveStatus;
- (void)setPrimitiveStatus:(NSNumber*)value;

- (uint16_t)primitiveStatusValue;
- (void)setPrimitiveStatusValue:(uint16_t)value_;

- (MDPFootballTeamDataModel*)primitiveFootballTeamDataPlayerLineUp;
- (void)setPrimitiveFootballTeamDataPlayerLineUp:(MDPFootballTeamDataModel*)value;

- (MDPKeyValueObjectModel*)primitivePosition;
- (void)setPrimitivePosition:(MDPKeyValueObjectModel*)value;

@end
