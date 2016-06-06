//
//  _MDPBasketLineUpPlayerModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPBasketLineUpPlayerModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPBasketLineUpPlayerModelAttributes {
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *playerId;
	__unsafe_unretained NSString *playerName;
	__unsafe_unretained NSString *tShirtNumber;
} MDPBasketLineUpPlayerModelAttributes;

extern const struct MDPBasketLineUpPlayerModelRelationships {
	__unsafe_unretained NSString *basketTeamDataLineUp;
	__unsafe_unretained NSString *position;
} MDPBasketLineUpPlayerModelRelationships;

@class MDPBasketTeamDataModel;
@class MDPKeyValueObjectModel;

@interface _MDPBasketLineUpPlayerModel : NSManagedObject

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* playerId;

//- (BOOL)validatePlayerId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* playerName;

//- (BOOL)validatePlayerName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* tShirtNumber;

//- (BOOL)validateTShirtNumber:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPBasketTeamDataModel *basketTeamDataLineUp;

//- (BOOL)validateBasketTeamDataLineUp:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPKeyValueObjectModel *position;

//- (BOOL)validatePosition:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPBasketLineUpPlayerModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitivePlayerId;
- (void)setPrimitivePlayerId:(NSString*)value;

- (NSString*)primitivePlayerName;
- (void)setPrimitivePlayerName:(NSString*)value;

- (NSString*)primitiveTShirtNumber;
- (void)setPrimitiveTShirtNumber:(NSString*)value;

- (MDPBasketTeamDataModel*)primitiveBasketTeamDataLineUp;
- (void)setPrimitiveBasketTeamDataLineUp:(MDPBasketTeamDataModel*)value;

- (MDPKeyValueObjectModel*)primitivePosition;
- (void)setPrimitivePosition:(MDPKeyValueObjectModel*)value;

@end
