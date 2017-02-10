//
//  _MDPProfileAvatarModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPProfileAvatarModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPProfileAvatarModelAttributes {
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *pictureUrl;
} MDPProfileAvatarModelAttributes;

extern const struct MDPProfileAvatarModelRelationships {
	__unsafe_unretained NSString *accesories;
	__unsafe_unretained NSString *physicalProperties;
} MDPProfileAvatarModelRelationships;

@class MDPProfileAvatarAccessoryItemModel;
@class MDPProfileAvatarItemModel;

@interface _MDPProfileAvatarModel : NSManagedObject

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* pictureUrl;

//- (BOOL)validatePictureUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *accesories;

- (NSMutableSet*)accesoriesSet;

@property (nonatomic, strong) NSSet *physicalProperties;

- (NSMutableSet*)physicalPropertiesSet;

@end

@interface _MDPProfileAvatarModel (AccesoriesCoreDataGeneratedAccessors)
- (void)addAccesories:(NSSet*)value_;
- (void)removeAccesories:(NSSet*)value_;
- (void)addAccesoriesObject:(MDPProfileAvatarAccessoryItemModel*)value_;
- (void)removeAccesoriesObject:(MDPProfileAvatarAccessoryItemModel*)value_;
@end

@interface _MDPProfileAvatarModel (PhysicalPropertiesCoreDataGeneratedAccessors)
- (void)addPhysicalProperties:(NSSet*)value_;
- (void)removePhysicalProperties:(NSSet*)value_;
- (void)addPhysicalPropertiesObject:(MDPProfileAvatarItemModel*)value_;
- (void)removePhysicalPropertiesObject:(MDPProfileAvatarItemModel*)value_;
@end

@interface _MDPProfileAvatarModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitivePictureUrl;
- (void)setPrimitivePictureUrl:(NSString*)value;

- (NSMutableSet*)primitiveAccesories;
- (void)setPrimitiveAccesories:(NSMutableSet*)value;

- (NSMutableSet*)primitivePhysicalProperties;
- (void)setPrimitivePhysicalProperties:(NSMutableSet*)value;

@end
