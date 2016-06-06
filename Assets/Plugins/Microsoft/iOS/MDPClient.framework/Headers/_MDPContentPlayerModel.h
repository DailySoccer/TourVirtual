//
//  _MDPContentPlayerModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPContentPlayerModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPContentPlayerModelAttributes {
	__unsafe_unretained NSString *aboutUrl;
	__unsafe_unretained NSString *idPlayer;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *pictureUrl;
} MDPContentPlayerModelAttributes;

extern const struct MDPContentPlayerModelRelationships {
	__unsafe_unretained NSString *contentRelatedPlayers;
} MDPContentPlayerModelRelationships;

@class MDPContentModel;

@interface _MDPContentPlayerModel : NSManagedObject

@property (nonatomic, strong) NSString* aboutUrl;

//- (BOOL)validateAboutUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idPlayer;

//- (BOOL)validateIdPlayer:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* pictureUrl;

//- (BOOL)validatePictureUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *contentRelatedPlayers;

- (NSMutableSet*)contentRelatedPlayersSet;

@end

@interface _MDPContentPlayerModel (ContentRelatedPlayersCoreDataGeneratedAccessors)
- (void)addContentRelatedPlayers:(NSSet*)value_;
- (void)removeContentRelatedPlayers:(NSSet*)value_;
- (void)addContentRelatedPlayersObject:(MDPContentModel*)value_;
- (void)removeContentRelatedPlayersObject:(MDPContentModel*)value_;
@end

@interface _MDPContentPlayerModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAboutUrl;
- (void)setPrimitiveAboutUrl:(NSString*)value;

- (NSString*)primitiveIdPlayer;
- (void)setPrimitiveIdPlayer:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSString*)primitivePictureUrl;
- (void)setPrimitivePictureUrl:(NSString*)value;

- (NSMutableSet*)primitiveContentRelatedPlayers;
- (void)setPrimitiveContentRelatedPlayers:(NSMutableSet*)value;

@end
